CREATE DATABASE Core;

GRANT ALL PRIVILEGES ON Core.* TO 'dev'@'%';

create table Core.Users
(
    Id    char(36)     not null,
    Email varchar(100) not null,
    Name  varchar(100) not null,
    constraint Users_pk
        primary key (Id)
);

create unique index Users_Id_uindex
    on Core.Users (Id);

create table Core.Articles
(
    Id       char(36)      not null,
    Url      varchar(2083) not null,
    PosterId char(36)      not null,
    constraint Articles_pk
        primary key (Id),
    constraint Articles_Users_Id_fk
        foreign key (PosterId) references Core.Users (Id)
);

create unique index Articles_Id_uindex
    on Core.Articles (Id);

