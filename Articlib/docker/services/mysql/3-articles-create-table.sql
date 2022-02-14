create table Articlib.Articles
(
    Id             char(36)      not null
        collate ascii_general_ci,
    Url            varchar(2083) not null,
    VoteCount      int unsigned  not null,
    PostedCount    int unsigned  not null,
    LastPostedDate datetime      not null,
    constraint Articles_pk
        primary key (Id)
);
