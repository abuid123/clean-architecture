using CleanArchitecture.Domain.Abstactions;

namespace CleanArchitecture.Domain.Vehiculos;

public sealed class Vehiculo(
    Guid id,
    Modelo modelo,
    Vin vin,
    Direccion direccion,
    Moneda precio,
    Moneda mantenimiento,
    DateTime fechaUltimaAlquiler,
    List<Accesorio> accesorios
        ) : Entity(id)
{
    public Modelo? Modelo { get; private set; } = modelo;
    public Vin? Vin { get; private set; } = vin;
    public Direccion? Direccion { get; private set; } = direccion;
    public Moneda? Precio { get; private set; } = precio;
    public Moneda? Mantenimiento { get; private set; } = mantenimiento;
    public DateTime? FechaUltimaAlquiler { get; internal set; } = fechaUltimaAlquiler;
    public List<Accesorio> Accesorios { get; private set; } = accesorios;
}