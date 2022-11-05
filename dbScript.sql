﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE companies (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "createDate" timestamp with time zone NOT NULL,
    "modifyDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_companies" PRIMARY KEY ("Id")
);

CREATE TABLE roles (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "createDate" timestamp with time zone NOT NULL,
    "modifyDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_roles" PRIMARY KEY ("Id")
);

CREATE TABLE departments (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    budget money NOT NULL,
    "BugetPlanId" integer NOT NULL,
    "CompanyId" integer NOT NULL,
    "createDate" timestamp with time zone NOT NULL,
    "modifyDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_departments" PRIMARY KEY ("Id"),
    CONSTRAINT "AK_departments_CompanyId_Name" UNIQUE ("CompanyId", "Name"),
    CONSTRAINT "FK_departments_companies_CompanyId" FOREIGN KEY ("CompanyId") REFERENCES companies ("Id") ON DELETE CASCADE
);

CREATE TABLE "expenseTypes" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "Limit" money NOT NULL,
    "CompanyId" integer NOT NULL,
    "createDate" timestamp with time zone NOT NULL,
    "modifyDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_expenseTypes" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_expenseTypes_companies_CompanyId" FOREIGN KEY ("CompanyId") REFERENCES companies ("Id") ON DELETE CASCADE
);

CREATE TABLE "bugetPlans" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "DeparmentId" integer NOT NULL,
    "January" money NOT NULL,
    "February" money NOT NULL,
    "March" money NOT NULL,
    "April" money NOT NULL,
    "May" money NOT NULL,
    "June" money NOT NULL,
    "July" money NOT NULL,
    "August" money NOT NULL,
    "September" money NOT NULL,
    "October" money NOT NULL,
    "November" money NOT NULL,
    "December" money NOT NULL,
    "createDate" timestamp with time zone NOT NULL,
    "modifyDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_bugetPlans" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_bugetPlans_departments_DeparmentId" FOREIGN KEY ("DeparmentId") REFERENCES departments ("Id") ON DELETE CASCADE
);

CREATE TABLE employees (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Email" text NOT NULL,
    "Password" text NOT NULL,
    "RoleId" integer NOT NULL,
    "DepartmentId" integer NULL,
    "createDate" timestamp with time zone NOT NULL,
    "modifyDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_employees" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_employees_departments_DepartmentId" FOREIGN KEY ("DepartmentId") REFERENCES departments ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_employees_roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES roles ("Id") ON DELETE CASCADE
);

CREATE TABLE expenses (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Confirm" boolean NOT NULL,
    "Valid" boolean NOT NULL,
    "ExpenseTypeId" integer NOT NULL,
    date timestamp with time zone NOT NULL,
    amount money NOT NULL,
    "DepartmentId" integer NOT NULL,
    "EmploeeId" integer NOT NULL,
    "employeeId" integer NULL,
    "createDate" timestamp with time zone NOT NULL,
    "modifyDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_expenses" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_expenses_departments_DepartmentId" FOREIGN KEY ("DepartmentId") REFERENCES departments ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_expenses_employees_employeeId" FOREIGN KEY ("employeeId") REFERENCES employees ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_expenses_expenseTypes_ExpenseTypeId" FOREIGN KEY ("ExpenseTypeId") REFERENCES "expenseTypes" ("Id") ON DELETE CASCADE
);

INSERT INTO roles ("Id", "Name", "createDate", "modifyDate")
VALUES (1, 'owner', TIMESTAMPTZ '2022-10-12 13:57:46.3531+03:00', TIMESTAMPTZ '2022-10-12 13:57:46.353102+03:00');
INSERT INTO roles ("Id", "Name", "createDate", "modifyDate")
VALUES (2, 'accountant', TIMESTAMPTZ '2022-10-12 13:57:46.353102+03:00', TIMESTAMPTZ '2022-10-12 13:57:46.353102+03:00');
INSERT INTO roles ("Id", "Name", "createDate", "modifyDate")
VALUES (3, 'user', TIMESTAMPTZ '2022-10-12 13:57:46.353102+03:00', TIMESTAMPTZ '2022-10-12 13:57:46.353102+03:00');

CREATE UNIQUE INDEX "IX_bugetPlans_DeparmentId" ON "bugetPlans" ("DeparmentId");

CREATE INDEX "IX_employees_DepartmentId" ON employees ("DepartmentId");

CREATE INDEX "IX_employees_RoleId" ON employees ("RoleId");

CREATE INDEX "IX_expenses_DepartmentId" ON expenses ("DepartmentId");

CREATE INDEX "IX_expenses_employeeId" ON expenses ("employeeId");

CREATE INDEX "IX_expenses_ExpenseTypeId" ON expenses ("ExpenseTypeId");

CREATE INDEX "IX_expenseTypes_CompanyId" ON "expenseTypes" ("CompanyId");

SELECT setval(
    pg_get_serial_sequence('roles', 'Id'),
    GREATEST(
        (SELECT MAX("Id") FROM roles) + 1,
        nextval(pg_get_serial_sequence('roles', 'Id'))),
    false);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221012105746_addCreateModifyDate', '6.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE employees DROP CONSTRAINT "FK_employees_roles_RoleId";

ALTER TABLE employees DROP COLUMN "Email";

ALTER TABLE employees DROP COLUMN "Name";

ALTER TABLE employees DROP COLUMN "Password";

ALTER TABLE employees ALTER COLUMN "RoleId" DROP NOT NULL;

ALTER TABLE employees ADD "UserId" integer NOT NULL DEFAULT 0;

CREATE TABLE users (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Email" text NOT NULL,
    "Password" text NOT NULL,
    "RoleId" integer NOT NULL,
    "createDate" timestamp with time zone NOT NULL,
    "modifyDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_users" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_users_roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES roles ("Id") ON DELETE CASCADE
);

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-12 16:07:44.535578+03:00', "modifyDate" = TIMESTAMPTZ '2022-10-12 16:07:44.535581+03:00'
WHERE "Id" = 1;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-12 16:07:44.535581+03:00', "modifyDate" = TIMESTAMPTZ '2022-10-12 16:07:44.535581+03:00'
WHERE "Id" = 2;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-12 16:07:44.535582+03:00', "modifyDate" = TIMESTAMPTZ '2022-10-12 16:07:44.535582+03:00'
WHERE "Id" = 3;

CREATE INDEX "IX_employees_UserId" ON employees ("UserId");

CREATE INDEX "IX_users_RoleId" ON users ("RoleId");

ALTER TABLE employees ADD CONSTRAINT "FK_employees_roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES roles ("Id");

ALTER TABLE employees ADD CONSTRAINT "FK_employees_users_UserId" FOREIGN KEY ("UserId") REFERENCES users ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221012130744_addUser', '6.0.10');

COMMIT;

START TRANSACTION;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-12 13:29:01.138893Z', "modifyDate" = TIMESTAMPTZ '2022-10-12 13:29:01.138893Z'
WHERE "Id" = 1;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-12 13:29:01.138893Z', "modifyDate" = TIMESTAMPTZ '2022-10-12 13:29:01.138893Z'
WHERE "Id" = 2;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-12 13:29:01.138893Z', "modifyDate" = TIMESTAMPTZ '2022-10-12 13:29:01.138893Z'
WHERE "Id" = 3;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221012132901_changeTypeDateTime', '6.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE employees DROP CONSTRAINT "FK_employees_roles_RoleId";

DROP INDEX "IX_employees_RoleId";

ALTER TABLE employees DROP COLUMN "RoleId";

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-12 14:52:01.302701Z', "modifyDate" = TIMESTAMPTZ '2022-10-12 14:52:01.302701Z'
WHERE "Id" = 1;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-12 14:52:01.302702Z', "modifyDate" = TIMESTAMPTZ '2022-10-12 14:52:01.302702Z'
WHERE "Id" = 2;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-12 14:52:01.302702Z', "modifyDate" = TIMESTAMPTZ '2022-10-12 14:52:01.302702Z'
WHERE "Id" = 3;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221012145201_changeTypeInRole', '6.0.10');

COMMIT;

START TRANSACTION;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-22 14:44:15.680922Z', "modifyDate" = TIMESTAMPTZ '2022-10-22 14:44:15.680922Z'
WHERE "Id" = 1;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-22 14:44:15.680922Z', "modifyDate" = TIMESTAMPTZ '2022-10-22 14:44:15.680922Z'
WHERE "Id" = 2;

UPDATE roles SET "createDate" = TIMESTAMPTZ '2022-10-22 14:44:15.680922Z', "modifyDate" = TIMESTAMPTZ '2022-10-22 14:44:15.680922Z'
WHERE "Id" = 3;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221022144415_addMigration', '6.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE employees DROP CONSTRAINT "FK_employees_users_UserId";

DROP TABLE users;

DROP TABLE roles;

DROP INDEX "IX_employees_UserId";

ALTER TABLE employees DROP COLUMN "UserId";

ALTER TABLE employees ADD "Name" text NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221105193845_removeAuth', '6.0.10');

COMMIT;

