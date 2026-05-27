# cs-performance-monitor

Un monitor de rendimiento del sistema en consola escrito en C# nativo para .NET Core. Proporciona diagnósticos asíncronos en tiempo real sobre el uso de memoria asignada en el proceso y análisis recursivo del espacio disponible en discos del sistema operativo.

## Características

- **Dashboard Integrado**: Renderizado dinámico por bloques en consola sin flickering de pantalla.
- **Detección Multiplataforma**: Utiliza las APIs modernas de `System.Runtime.InteropServices` para identificar los detalles del kernel (Windows, macOS o distribuciones Linux).
- **ProgressBar visual**: Barra gráfica renderizada por caracteres que cambia de color según el umbral de ocupación (Verde, Amarillo, Rojo).

## Vista previa en consola

```
==================================================
   C# System Performance Monitor - Real-Time Dashboard
==================================================
Presiona [Ctrl+C] para salir de la simulación.

💻 ESPECIFICACIONES DE COMPUTADORA
• Sistema Operativo : Microsoft Windows 10.0.19045
• Arquitectura      : X64
• Núcleos de CPU    : 16 lógicos

--------------------------------------------------
📊 ESTADÍSTICAS EN TIEMPO REAL
• RAM Usada (Proceso) : 4.12 MB
• SSD Principal Libre  : 245.10 GB / 499.90 GB
• Uso de Almacenamiento: [██████████░░░░░░░░░░] 50.9%

--------------------------------------------------
Actualizado en: 22:15:30
```

## Compilación y Ejecución

Necesitas tener instalado el [.NET SDK](https://dotnet.microsoft.com/download) en tu PC.

```bash
git clone https://github.com/davestinhast/cs-performance-monitor.git
cd cs-performance-monitor
dotnet run
```

Para compilar un binario optimizado de producción:
```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

## Estructura de Archivos

```
cs-performance-monitor/
├── cs-performance-monitor.csproj  — Configuración del proyecto .NET
├── Program.cs                     — Lógica del dashboard y consultas
└── README.md                      — Documentación técnica en español
```

## Licencia
MIT
