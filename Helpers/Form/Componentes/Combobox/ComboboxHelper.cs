using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

public static class ComboBoxHelper
{
    public static void PreencherComboComDbSet<T>(
        this ComboBox combo,
        DbContext context,
        Func<T, string> displaySelector,
        Func<T, object> valueSelector,
        bool filtrarAtivo = true) where T : class
    {
        var query = context.Set<T>().AsQueryable();

        if (filtrarAtivo && typeof(T).GetProperty("Ativo") != null)
            query = query.Where(e => EF.Property<bool>(e, "Ativo"));

        var itens = query
            .AsNoTracking()
            .ToList() // materializa no servidor antes de aplicar delegates
            .Select(x =>
            {
                var valorOriginal = valueSelector(x);
                return new
                {
                    Texto = displaySelector(x),
                    ValorOriginal = valorOriginal,
                    // chave “amigável” p/ SelectedValue = int
                    ValorNormalizado = NormalizarChave(valorOriginal)
                };
            })
            .ToList();

        // Mostre o texto, mas faça o binding pelo valor normalizado
        combo.DisplayMember = "Texto";
        combo.ValueMember = "ValorNormalizado";
        combo.DataSource = itens;

        // (opcional) evita seleção automática do primeiro item
        // combo.SelectedIndex = -1;
    }

    /// <summary>
    /// Tenta converter a chave para int quando possível, preservando o tipo original nos casos não numéricos.
    /// Isso permite que SelectedValue=int case com ids long/short/byte/string-numérica.
    /// </summary>
    private static object? NormalizarChave(object? valor)
    {
        if (valor is null) return null;

        // Desembrulha Nullable<T>
        var tipo = Nullable.GetUnderlyingType(valor.GetType()) ?? valor.GetType();

        // Se já for int, mantenha
        if (tipo == typeof(int)) return valor;

        // Numéricos que caibam em int
        try
        {
            if (valor is IConvertible)
            {
                // Evita overflow: converte p/ Int64 primeiro e verifica faixa
                long l = Convert.ToInt64(valor, CultureInfo.InvariantCulture);
                if (l >= int.MinValue && l <= int.MaxValue)
                    return (int)l;
            }
        }
        catch { /* ignora e tenta outras formas */ }

        // String numérica -> int (se couber)
        if (valor is string s)
        {
            s = s.Trim();
            if (Regex.IsMatch(s, @"^[+-]?\d+$") && long.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var l2))
            {
                if (l2 >= int.MinValue && l2 <= int.MaxValue)
                    return (int)l2;
            }
            return s; // mantém string não numérica (ex.: GUID textual)
        }

        // Para GUIDs, longs fora da faixa de int, etc., preserva o tipo
        return valor;
    }
}
