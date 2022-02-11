create table Articlib.ArticlePosts
(
    UserId     char(36) not null,
    ArticleId  char(36) not null,
    PostedDate datetime not null,
    constraint ArticlePosts_pk
        primary key (UserId, ArticleId),
    constraint ArticlePosts_Articles_Id_fk
        foreign key (ArticleId) references Articles (Id),
    constraint ArticlePosts_AspNetUsers_Id_fk
        foreign key (UserId) references AspNetUsers (Id)
);
