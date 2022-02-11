create table Articlib.ArticlePosts
(
    UserId     char(36) not null
        collate ascii_general_ci,
    ArticleId  char(36) not null
        collate ascii_general_ci,
    PostDate datetime not null,
    constraint ArticlePosts_pk
        primary key (UserId, ArticleId),
    constraint ArticlePosts_Articles_Id_fk
        foreign key (ArticleId) references Articles (Id),
    constraint ArticlePosts_AspNetUsers_Id_fk
        foreign key (UserId) references AspNetUsers (Id)
);
