using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Vehiculos;

public record TipoMoneda
{
  public static readonly TipoMoneda None = new("");
  public static readonly TipoMoneda Usd = new("USD");
  public static readonly TipoMoneda Eur = new("EUR");
  private TipoMoneda(string codigo) => Codigo = codigo;
  public string? Codigo { get; init; }

  public static readonly IReadOnlyCollection<TipoMoneda> All =
  [
    Usd,
    Eur
  ];

  public static TipoMoneda FromCodigo(string codigo)
  {
    return All.FirstOrDefault(x => x.Codigo == codigo) ?? throw new ApplicationException($"Tipo de moneda no soportado: {codigo}");
  }
}