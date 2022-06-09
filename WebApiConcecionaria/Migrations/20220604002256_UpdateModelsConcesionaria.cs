using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiConcecionaria.Migrations
{
    public partial class UpdateModelsConcesionaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_clienteidCliente",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Vehiculos_vehiculoidVehculo",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_clienteidCliente",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_vehiculoidVehculo",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "clienteidCliente",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "vehiculoidVehculo",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "importe",
                table: "Ventas",
                newName: "Importe");

            migrationBuilder.RenameColumn(
                name: "fecha",
                table: "Ventas",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "descuento",
                table: "Ventas",
                newName: "Descuento");

            migrationBuilder.RenameColumn(
                name: "idVehiculo",
                table: "Ventas",
                newName: "VehiculoId");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Ventas",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "idVenta",
                table: "Ventas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "precio",
                table: "Vehiculos",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "modelo",
                table: "Vehiculos",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "marca",
                table: "Vehiculos",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "fechaBaja",
                table: "Vehiculos",
                newName: "FechaBaja");

            migrationBuilder.RenameColumn(
                name: "idVehculo",
                table: "Vehiculos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "dni",
                table: "Clientes",
                newName: "DNI");

            migrationBuilder.RenameColumn(
                name: "dieccion",
                table: "Clientes",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "Apelido",
                table: "Clientes",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Clientes",
                newName: "Id");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_VehiculoId",
                table: "Ventas",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Vehiculos_VehiculoId",
                table: "Ventas",
                column: "VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Vehiculos_VehiculoId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_VehiculoId",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "Importe",
                table: "Ventas",
                newName: "importe");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Ventas",
                newName: "fecha");

            migrationBuilder.RenameColumn(
                name: "Descuento",
                table: "Ventas",
                newName: "descuento");

            migrationBuilder.RenameColumn(
                name: "VehiculoId",
                table: "Ventas",
                newName: "idVehiculo");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Ventas",
                newName: "idCliente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ventas",
                newName: "idVenta");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Vehiculos",
                newName: "precio");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Vehiculos",
                newName: "modelo");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Vehiculos",
                newName: "marca");

            migrationBuilder.RenameColumn(
                name: "FechaBaja",
                table: "Vehiculos",
                newName: "fechaBaja");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vehiculos",
                newName: "idVehculo");

            migrationBuilder.RenameColumn(
                name: "DNI",
                table: "Clientes",
                newName: "dni");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Clientes",
                newName: "dieccion");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Clientes",
                newName: "Apelido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "idCliente");

            migrationBuilder.AddColumn<int>(
                name: "clienteidCliente",
                table: "Ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vehiculoidVehculo",
                table: "Ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_clienteidCliente",
                table: "Ventas",
                column: "clienteidCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_vehiculoidVehculo",
                table: "Ventas",
                column: "vehiculoidVehculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_clienteidCliente",
                table: "Ventas",
                column: "clienteidCliente",
                principalTable: "Clientes",
                principalColumn: "idCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Vehiculos_vehiculoidVehculo",
                table: "Ventas",
                column: "vehiculoidVehculo",
                principalTable: "Vehiculos",
                principalColumn: "idVehculo");
        }
    }
}
