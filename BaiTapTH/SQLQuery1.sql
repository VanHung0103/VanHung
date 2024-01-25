CREATE TABLE HocSinh (
 Ten varchar(100),
 Diachi varchar(255),
 Cmnd varchar(100),
);
go

USING QLHocSinh
go

INSERT INTO HocSinh (Ten, Diachi, Cmnd)
VALUES ('nva', 'hcm', '123','2/3/2003');
INSERT INTO HocSinh (Ten, Diachi, Cmnd)
VALUES ('nva2', 'hcm', '123','4/5/2003');
INSERT INTO HocSinh (Ten, Diachi, Cmnd)
VALUES ('nva3', 'hcm', '123','6/7/2003');
INSERT INTO HocSinh (Ten, Diachi, Cmnd)
VALUES ('nva4', 'hcm', '123','1/3/2004');
INSERT INTO HocSinh (Ten, Diachi, Cmnd)
VALUES ('nva5', 'hcm', '123','1/11/2003');
select * from HocSinh