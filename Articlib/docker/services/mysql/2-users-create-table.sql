create table Articlib.AspNetUsers
(
    Id                   char(36)   not null
        collate ascii_general_ci
        primary key,
    Email                varchar(100) not null,
    NormalizedEmail      varchar(100) not null,
    UserName             varchar(100) not null,
    NormalizedUserName   varchar(100) not null,
    PasswordHash         char(84)     not null,
    AccessFailedCount    int          not null,
    ConcurrencyStamp     varchar(255) not null,
    EmailConfirmed       tinyint(1)   not null,
    LockoutEnabled       tinyint(1)   not null,
    LockoutEnd           datetime     null,
    PhoneNumber          char(12)     null,
    PhoneNumberConfirmed tinyint(1)   null,
    SecurityStamp        varchar(100) not null,
    TwoFactorEnabled     tinyint(1)   null,
    constraint AspNetUsers_Id_uindex
        unique (Id)
);