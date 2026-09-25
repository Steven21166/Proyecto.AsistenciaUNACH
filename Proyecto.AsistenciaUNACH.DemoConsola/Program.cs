using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto.AsistenciaUNACH.Persistencia.Models;
using Proyecto.AsistenciaUNACH.Persistencia.Repositorios;

var options = new DbContextOptionsBuilder<AsistenciaUNACHContext>()
    .UseSqlServer(
        "Server=DESKTOP-1CFFTHH;Database=AsistenciaUNACH;Trusted_Connection=True;TrustServerCertificate=True;"
    )
    .Options;

using var context = new AsistenciaUNACHContext(options);


// =========================================
// CARRERAS
// =========================================

ICarreraRepositorio carreraRepositorio =
    new CarreraRepositorio(context);

var carreras = await carreraRepositorio.ObtenerTodas();

Console.WriteLine("========== CARRERAS ==========");

foreach (var carrera in carreras)
{
    Console.WriteLine(
        $"{carrera.IdCarrera} - " +
        $"{carrera.CodigoCarrera} - " +
        $"{carrera.NombreCarrera}"
    );
}


// =========================================
// ASIGNATURAS
// =========================================

IAsignaturaRepositorio asignaturaRepositorio =
    new AsignaturaRepositorio(context);

var asignaturas = await asignaturaRepositorio.ObtenerTodas();

Console.WriteLine();
Console.WriteLine("========== ASIGNATURAS ==========");

foreach (var asignatura in asignaturas)
{
    Console.WriteLine(
        $"{asignatura.IdAsignatura} - " +
        $"{asignatura.CodigoAsignatura} - " +
        $"{asignatura.NombreAsignatura} - " +
        $"Semestre: {asignatura.Semestre}"
    );
}


// =========================================
// DOCENTES
// =========================================

IDocenteRepositorio docenteRepositorio =
    new DocenteRepositorio(context);

var docentes = await docenteRepositorio.ObtenerTodos();

Console.WriteLine();
Console.WriteLine("========== DOCENTES ==========");

foreach (var docente in docentes)
{
    Console.WriteLine(
        $"ID: {docente.IdDocente}"
    );

    Console.WriteLine(
        $"Nombre: {docente.Nombres} {docente.Apellidos}"
    );

    Console.WriteLine(
        $"Cédula: {docente.Cedula}"
    );

    Console.WriteLine(
        $"Correo: {docente.Correo}"
    );

    Console.WriteLine(
        $"Carrera: {docente.IdCarreraNavigation.NombreCarrera}"
    );

    Console.WriteLine(
        $"Asignatura: {docente.IdAsignaturaNavigation.NombreAsignatura}"
    );

    Console.WriteLine(
        $"Fecha: {docente.FechaAsistencia}"
    );

    Console.WriteLine(
        $"Entrada: {docente.HoraEntrada}"
    );

    Console.WriteLine(
        $"Salida: {docente.HoraSalida}"
    );

    Console.WriteLine(
        $"Estado: {docente.EstadoAsistencia}"
    );

    Console.WriteLine("--------------------------------");
}

Console.WriteLine();
Console.WriteLine("Prueba finalizada. Presiona una tecla para salir...");
Console.ReadKey();