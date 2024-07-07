﻿using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infraestructure.Configurations;

internal sealed class AlquilerConfiguration : IEntityTypeConfiguration<Alquiler>
{
    public void Configure(EntityTypeBuilder<Alquiler> builder)
    {
        builder.ToTable("alquiler");
        builder.HasKey(a => a.Id);

        builder.OwnsOne(alquiler => alquiler.PrecioPorPeriodo, precioBuilder =>
        {
            precioBuilder.Property(moneda => moneda.TipoMoneda)
            .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
        });

        builder.OwnsOne(alquiler => alquiler.Mantenimiento, precioBuilder =>
        {
            precioBuilder.Property(moneda => moneda.TipoMoneda)
            .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
        });

        builder.OwnsOne(alquiler => alquiler.Accesorios, precioBuilder =>
        {
            precioBuilder.Property(moneda => moneda.TipoMoneda)
            .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
        });

        builder.OwnsOne(alquiler => alquiler.PrecioTotal, precioBuilder =>
        {
            precioBuilder.Property(moneda => moneda.TipoMoneda)
            .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
        });

        builder.OwnsOne(alquiler => alquiler.DuracionAlquiler);

        // Relacion con Vehiculo de uno a muchos
        builder.HasOne<Vehiculo>()
            .WithMany()
            .HasForeignKey(alquiler => alquiler.VehiculoId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(alquiler => alquiler.UserId);
    }
}
