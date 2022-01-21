create table Articlib.Votes
(
    ArticleId char(36) not null
        collate ascii_general_ci,
    UserId    char(36) not null
        collate ascii_general_ci,
    Date      datetime not null,
    constraint Votes_pk
        primary key (ArticleId, UserId),
    constraint Votes_Articles_Id_fk
        foreign key (ArticleId) references Articles (Id),
    constraint Votes_AspNetUsers_Id_fk
        foreign key (UserId) references AspNetUsers (Id)
);
