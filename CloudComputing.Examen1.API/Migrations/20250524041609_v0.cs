using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudComputing.Examen1.API.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Espacios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espacios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedioPagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedioPagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correoelectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEventosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_TipoEventos_TipoEventosId",
                        column: x => x.TipoEventosId,
                        principalTable: "TipoEventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cuerpo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlPdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificados_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventoPonentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PonentesId = table.Column<int>(type: "int", nullable: false),
                    EventosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoPonentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventoPonentes_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoPonentes_Ponentes_PonentesId",
                        column: x => x.PonentesId,
                        principalTable: "Ponentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCertificados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Participante = table.Column<int>(type: "int", nullable: false),
                    Evento = table.Column<int>(type: "int", nullable: false),
                    Certificado = table.Column<int>(type: "int", nullable: false),
                    Pago = table.Column<int>(type: "int", nullable: false),
                    EventosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCertificados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoCertificados_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantesId = table.Column<int>(type: "int", nullable: false),
                    EventosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Participantes_ParticipantesId",
                        column: x => x.ParticipantesId,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EspaciosId = table.Column<int>(type: "int", nullable: false),
                    EventosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sesiones_Espacios_EspaciosId",
                        column: x => x.EspaciosId,
                        principalTable: "Espacios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sesiones_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoTransaccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedioPagosId = table.Column<int>(type: "int", nullable: false),
                    InscripcionesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripciones_InscripcionesId",
                        column: x => x.InscripcionesId,
                        principalTable: "Inscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_MedioPagos_MedioPagosId",
                        column: x => x.MedioPagosId,
                        principalTable: "MedioPagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_EventosId",
                table: "Certificados",
                column: "EventosId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventosId",
                table: "Eventos",
                column: "TipoEventosId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoPonentes_EventosId",
                table: "EventoPonentes",
                column: "EventosId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoPonentes_PonentesId",
                table: "EventoPonentes",
                column: "PonentesId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCertificados_EventosId",
                table: "HistoricoCertificados",
                column: "EventosId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventosId",
                table: "Inscripciones",
                column: "EventosId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParticipantesId",
                table: "Inscripciones",
                column: "ParticipantesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionesId",
                table: "Pagos",
                column: "InscripcionesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_MedioPagosId",
                table: "Pagos",
                column: "MedioPagosId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_EspaciosId",
                table: "Sesiones",
                column: "EspaciosId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_EventosId",
                table: "Sesiones",
                column: "EventosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "EventoPonentes");

            migrationBuilder.DropTable(
                name: "HistoricoCertificados");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "MedioPagos");

            migrationBuilder.DropTable(
                name: "Espacios");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "TipoEventos");
        }
    }
}
