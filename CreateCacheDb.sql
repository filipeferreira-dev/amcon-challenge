create database [ChallengeCache]

create table Summary 
(
	Id bigint not null identity constraint PK_Summary_Id primary key,
	MerchantsCount bigint not null,
	PurchaseCount bigint not null,
	PurchaseAmmount money not null, 
	UpdatedAt datetime not null
)

create table PurchaseDetail
(
	Id bigint not null identity constraint PK_PurchaseDetail_Id primary key,
	PurchaseDate datetime not null,
	Ammount money not null,
	MerchantName varchar(max),
	UpdatedAt datetime not null
)

create table PurchaseSummaryPerMerchant
(
	Id bigint not null identity constraint PK_PurchaseSummaryPerMerchant_Id primary key,
	PurchaseAmmount money not null,
	PurchaseCount bigint not null,
	MerchantName varchar(max),
	UpdatedAt datetime not null
)
