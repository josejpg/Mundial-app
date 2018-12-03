/* Formatted on 27/10/2018 19:26:33 (QP5 v5.326) */
DROP TABLE ROL_APP;

CREATE TABLE ROL_APP
(
    ID_ROL_APP              INTEGER NOT NULL,
    DESCRICPCION_ROL_APP    VARCHAR2 (60),
    CONSTRAINT PK_ROL_APP PRIMARY KEY (ID_ROL_APP)
);

DROP SEQUENCE ROLL_APP_SEQ;

CREATE SEQUENCE ROLL_APP_SEQ START WITH 1000 INCREMENT BY 1 NOCACHE NOCYCLE;

DROP TABLE USUARIO_APP;

CREATE TABLE USUARIO_APP
(
    ID_USUARIO_APP             INTEGER NOT NULL,
    NICK_USUARIO_APP           VARCHAR2 (50) UNIQUE,
    CONTRASENYA_USUARIO_APP    VARCHAR2 (32),                           -- MD5
    EMAIL_USUARIO_APP          VARCHAR2 (100),
    NOMBRE_USUARIO_APP         VARCHAR2 (80),
    APELLIDOS_USUARIO_APP      VARCHAR2 (150),
    FECHA_ALTA_USUARIO_APP     DATE,
    ROL_USUARIO_APP            INTEGER,
    FOTO_USUARIO_APP           BLOB,
    ACTIVO_USUARIO_APP         VARCHAR2 (1),
    CONSTRAINT PK_USUARIO_APP PRIMARY KEY (ID_USUARIO_APP),
    CONSTRAINT FK_USUARIO_APP_ROL_APP FOREIGN KEY (ROL_USUARIO_APP)
        REFERENCES ROL_APP (ID_ROL_APP)
);

DROP SEQUENCE USUARIO_APP_SEQ;

CREATE SEQUENCE USUARIO_APP_SEQ START WITH 1000
                                INCREMENT BY 1
                                NOCACHE
                                NOCYCLE;

INSERT INTO ROL_APP (ID_ROL_APP, DESCRICPCION_ROL_APP)
     VALUES (ROLL_APP_SEQ.NEXTVAL, 'Administrador');

INSERT INTO ROL_APP (ID_ROL_APP, DESCRICPCION_ROL_APP)
     VALUES (ROLL_APP_SEQ.NEXTVAL, 'Usuario');

-- Para el almacenamiento de las imágenes deberemos crear un directorio dentro del sistema operativo
-- dónde Oracla las alamcenará internamente y luego indicárselo con la siguiente instrucción

CREATE OR REPLACE DIRECTORY BLOB_DIR AS 'C:\BLOB';

ALTER TABLE JUGADOR
    ADD (FOTO_JUGADOR BLOB);


DROP TABLE TMP_STR_JUGADOR;

CREATE GLOBAL TEMPORARY TABLE TMP_STR_JUGADOR
ON COMMIT PRESERVE ROWS
AS
    (SELECT NOMBRE,
            DIRECCION,
            PUESTO_HAB,
            FECHA_NAC,
            EQUIPO_JUGADOR,
            FOTO_JUGADOR
       FROM jugador
      WHERE 1 = 0);

DROP TABLE tmp_estructura;

CREATE GLOBAL TEMPORARY TABLE tmp_estructura
(
    id_transaccion    NUMBER,
    origen_datos      VARCHAR2 (4000),
    n1                NUMBER,
    n2                NUMBER,
    n3                NUMBER,
    n4                NUMBER,
    n5                NUMBER,
    n6                NUMBER,
    n7                NUMBER,
    n8                NUMBER,
    n9                NUMBER,
    n10               NUMBER,
    c1                VARCHAR2 (4000),
    c2                VARCHAR2 (4000),
    c3                VARCHAR2 (4000),
    c4                VARCHAR2 (4000),
    c5                VARCHAR2 (4000),
    c6                VARCHAR2 (4000),
    c7                VARCHAR2 (4000),
    c9                VARCHAR2 (4000),
    c10               VARCHAR2 (4000),
    d1                DATE,
    d2                DATE,
    d3                DATE,
    d4                DATE,
    b1                 BLOB   
)
ON COMMIT PRESERVE ROWS;