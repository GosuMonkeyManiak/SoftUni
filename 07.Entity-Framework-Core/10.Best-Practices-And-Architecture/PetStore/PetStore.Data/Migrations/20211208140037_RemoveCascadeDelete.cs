namespace PetStore.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_PetTypes_PetTypeId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Decorations_DecorationDistributors_DecorationDistributorId",
                table: "Decorations");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodDistributors_FoodDistributorId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeLogs_CustomerServiceTypes_CustomerServiceTypeId",
                table: "IncomeLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentLogs_PaymentTypes_PaymentTypeId",
                table: "PaymentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Genders_GenderId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_PetTypes_PetTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Toys_ToyDistributors_ToyDistributorId",
                table: "Toys");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDecorations_Decorations_DecorationId",
                table: "UsersDecorations");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDecorations_Users_UserId",
                table: "UsersDecorations");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFoods_Foods_FoodId",
                table: "UsersFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFoods_Users_UserId",
                table: "UsersFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersServices_Services_ServiceId",
                table: "UsersServices");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersServices_Users_UserId",
                table: "UsersServices");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersToys_Toys_ToyId",
                table: "UsersToys");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersToys_Users_UserId",
                table: "UsersToys");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_PetTypes_PetTypeId",
                table: "Breeds",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Decorations_DecorationDistributors_DecorationDistributorId",
                table: "Decorations",
                column: "DecorationDistributorId",
                principalTable: "DecorationDistributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodDistributors_FoodDistributorId",
                table: "Foods",
                column: "FoodDistributorId",
                principalTable: "FoodDistributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeLogs_CustomerServiceTypes_CustomerServiceTypeId",
                table: "IncomeLogs",
                column: "CustomerServiceTypeId",
                principalTable: "CustomerServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentLogs_PaymentTypes_PaymentTypeId",
                table: "PaymentLogs",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Genders_GenderId",
                table: "Pets",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_PetTypes_PetTypeId",
                table: "Services",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_ToyDistributors_ToyDistributorId",
                table: "Toys",
                column: "ToyDistributorId",
                principalTable: "ToyDistributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDecorations_Decorations_DecorationId",
                table: "UsersDecorations",
                column: "DecorationId",
                principalTable: "Decorations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDecorations_Users_UserId",
                table: "UsersDecorations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFoods_Foods_FoodId",
                table: "UsersFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFoods_Users_UserId",
                table: "UsersFoods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersServices_Services_ServiceId",
                table: "UsersServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersServices_Users_UserId",
                table: "UsersServices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToys_Toys_ToyId",
                table: "UsersToys",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToys_Users_UserId",
                table: "UsersToys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_PetTypes_PetTypeId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Decorations_DecorationDistributors_DecorationDistributorId",
                table: "Decorations");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodDistributors_FoodDistributorId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeLogs_CustomerServiceTypes_CustomerServiceTypeId",
                table: "IncomeLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentLogs_PaymentTypes_PaymentTypeId",
                table: "PaymentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Genders_GenderId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_PetTypes_PetTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Toys_ToyDistributors_ToyDistributorId",
                table: "Toys");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDecorations_Decorations_DecorationId",
                table: "UsersDecorations");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDecorations_Users_UserId",
                table: "UsersDecorations");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFoods_Foods_FoodId",
                table: "UsersFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFoods_Users_UserId",
                table: "UsersFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersServices_Services_ServiceId",
                table: "UsersServices");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersServices_Users_UserId",
                table: "UsersServices");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersToys_Toys_ToyId",
                table: "UsersToys");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersToys_Users_UserId",
                table: "UsersToys");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_PetTypes_PetTypeId",
                table: "Breeds",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Decorations_DecorationDistributors_DecorationDistributorId",
                table: "Decorations",
                column: "DecorationDistributorId",
                principalTable: "DecorationDistributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodDistributors_FoodDistributorId",
                table: "Foods",
                column: "FoodDistributorId",
                principalTable: "FoodDistributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeLogs_CustomerServiceTypes_CustomerServiceTypeId",
                table: "IncomeLogs",
                column: "CustomerServiceTypeId",
                principalTable: "CustomerServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentLogs_PaymentTypes_PaymentTypeId",
                table: "PaymentLogs",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Genders_GenderId",
                table: "Pets",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_PetTypes_PetTypeId",
                table: "Services",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_ToyDistributors_ToyDistributorId",
                table: "Toys",
                column: "ToyDistributorId",
                principalTable: "ToyDistributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDecorations_Decorations_DecorationId",
                table: "UsersDecorations",
                column: "DecorationId",
                principalTable: "Decorations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDecorations_Users_UserId",
                table: "UsersDecorations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFoods_Foods_FoodId",
                table: "UsersFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFoods_Users_UserId",
                table: "UsersFoods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersServices_Services_ServiceId",
                table: "UsersServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersServices_Users_UserId",
                table: "UsersServices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToys_Toys_ToyId",
                table: "UsersToys",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToys_Users_UserId",
                table: "UsersToys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
