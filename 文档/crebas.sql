/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2017/1/20 1:01:56                            */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Album') and o.name = 'FK_ALBUM_REFERENCE_GENRE')
alter table Album
   drop constraint FK_ALBUM_REFERENCE_GENRE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Album') and o.name = 'FK_ALBUM_REFERENCE_ARTIST')
alter table Album
   drop constraint FK_ALBUM_REFERENCE_ARTIST
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Album')
            and   type = 'U')
   drop table Album
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Artist')
            and   type = 'U')
   drop table Artist
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Genre')
            and   type = 'U')
   drop table Genre
go

/*==============================================================*/
/* Table: Album                                                 */
/*==============================================================*/
create table Album (
   AlbumId              bigint               identity,
   GenreId              int                  not null,
   ArtistId             bigint               not null,
   Title                varchar(30)          not null,
   Price                float                not null,
   AlbumArtUrl          varchar(100)         not null,
   constraint PK_ALBUM primary key (AlbumId)
)
go

/*==============================================================*/
/* Table: Artist                                                */
/*==============================================================*/
create table Artist (
   ArtistId             bigint               identity,
   Name                 varchar(30)          not null,
   constraint PK_ARTIST primary key (ArtistId)
)
go

/*==============================================================*/
/* Table: Genre                                                 */
/*==============================================================*/
create table Genre (
   GenreId              int                  identity,
   Name                 varchar(30)          not null,
   Description          varchar(100)         not null,
   constraint PK_GENRE primary key (GenreId)
)
go

alter table Album
   add constraint FK_ALBUM_REFERENCE_GENRE foreign key (GenreId)
      references Genre (GenreId)
go

alter table Album
   add constraint FK_ALBUM_REFERENCE_ARTIST foreign key (ArtistId)
      references Artist (ArtistId)
go

