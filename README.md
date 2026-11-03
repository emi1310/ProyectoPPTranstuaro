# ProyectoPPTranstuaro
Proyecto para Práctiicas Profesionalizantes "Transportes Transtuaro"

## Versión actual

Abrir `Transtuaro.slnx` o `Transtuaro.csproj` con un SDK compatible con .NET 8 y Windows Forms.

```powershell
dotnet build Transtuaro.csproj --configuration Release
dotnet run --project Transtuaro.csproj
```

La versión actual incorpora reportes, exportación a PDF, anulación de remitos y la nueva interfaz de liquidaciones. Las dependencias Microsoft.Data.Sqlite y PDFsharp-GDI se restauran con NuGet.

Los archivos de la versión anterior, incluidos `Trastuaro V2.csproj` y su solución, se conservan. Usar el proyecto `Transtuaro.csproj`, que excluye de la compilación las clases y los formularios anteriores incompatibles.

Las bases de datos de pruebas y los archivos generados por Visual Studio no se incluyen. La aplicación crea `Transtuaro.db` en su directorio de ejecución al iniciar.