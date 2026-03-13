# CleanArchitectureIngenieria-master

EXPLICACIÓN

1)	¿Qué hace el patrón Repository en este proyecto?
Para este caso el patrón Repository actúa como una capa de abstracción entre la lógica de negocio (Application/Domain) y el acceso a los datos (Infrastructure), en un análisis hacia lo que realizamos en clase se puede evidenciar:
•	Desacoplamiento: Su función principal es que la aplicación no sepa cómo se guardan los datos (si es en SQL Server, una lista en memoria o una API externa), sino solo qué operaciones puede hacer.
•	Centralización: Evita duplicar consultas SQL en diferentes partes del sistema, centralizando el acceso a entidades como Producto, Almacén o Proveedor.

2) ¿Qué archivos creaste/modificaste para implementarlo?
Se modificaron los archivos de interfaces y de implementaciones que a su vez están en CleanArchitecture.Application  y CleanArchitecture.Infrastructure, en el archivo IRepositoryBase.cs se encuentra el método CRUD, además de realizar las herencias en desde unidad de medida para poder así conectar los datos.
Además de lo anterior mencionado se modificaron ProductoRepository.cs, AlmacenRepository.cs ya que cuentan con la lógica particular de cada entidad.

3) ¿Cómo se conecta tu Repository con la capa de infraestructura y la capa de aplicación?
La conexión entre las capas se realiza mediante Inyección de Dependencias, siguiendo el flujo de la Arquitectura Limpia. Primero, en la capa de Aplicación se definen las interfaces, por ejemplo, IProductoRepository, que establecen los contratos de acceso a los datos. Luego, en la capa de Infraestructura se crean las implementaciones de esas interfaces, como ProductoRepository, que utilizan ApplicationDbContext para comunicarse con SQL Server. Después, en el archivo ConfigurationServices.cs se registra la relación entre ambos, indicando que cuando el sistema solicite IProductoRepository, se le entregue una instancia de ProductoRepository. Finalmente, en la capa de Presentación, los Controllers reciben la interfaz a través de su constructor, lo que les permite usar sus métodos sin conocer ni depender directamente de la capa de infraestructura.

4) ¿Qué dificultades tuviste y cómo las resolviste (si aplica)?

La que mas me afecto fue la instalación de visual studio, pues al parecer tenía un registro de una versión antigua y no lograba reinstalar, finalmente con la actualización de java y un cambio de cuenta de Windows lo puede resolver.
A nivel de implementación de código tuve que realizar varios intentos con copilot, pues en efecto, aunque esta herramienta hace maravillas hay que pedirle puntualmente lo que se requiere para que la herramienta no haga mas de la cuenta, pues gracias a ello tuve que hacer dos intentos para poder crear los repositorios de manera completa y correcta.
Al momento de tratar de conectarlo al commit de github no logro ver los cambios, al parecer es por que tengo dos cuentas pero no logro desvincular una de ellas.
