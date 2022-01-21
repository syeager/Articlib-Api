create table Articlib.Articles
(
    Id       char(36)      not null
        collate ascii_general_ci,
    Url      varchar(2083) not null,
    PosterId char(36)      not null
        collate ascii_general_ci,
    constraint Articles_pk
        primary key (Id),
    constraint Articles_AspNetUsers_Id_fk
        foreign key (PosterId) references Articlib.AspNetUsers (Id)
);
