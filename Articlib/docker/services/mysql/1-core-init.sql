CREATE DATABASE Articlib CHARACTER SET utf8mb4;

GRANT ALL PRIVILEGES ON Articlib.* TO 'dev'@'%';

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

create table Articlib.Articles
(
    Id       char(36)      not null,
    Url      varchar(2083) not null,
    PosterId char(36)    not null
        collate ascii_general_ci,
    constraint Articles_pk
        primary key (Id),
    constraint Articles_AspNetUsers_Id_fk
        foreign key (PosterId) references Articlib.AspNetUsers (Id)
);
