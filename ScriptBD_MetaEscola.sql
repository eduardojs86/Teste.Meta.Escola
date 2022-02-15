CREATE TABLE [dbo].[Curso](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[PROC_INCLUIR_CURSO]
@Nome nvarchar(100)
AS
BEGIN   
INSERT INTO [dbo].[Curso]
           (Nome)
     VALUES
           (@Nome)
END

go
CREATE PROCEDURE [dbo].[PROC_EDITAR_CURSO]
@ID INT = NULL,
@Nome VARCHAR(100) = NULL
AS
BEGIN   
  UPDATE [dbo].[Curso]
   SET Nome = @Nome
 WHERE ID = @ID
END
go

CREATE PROCEDURE [dbo].[PROC_BUSCAR_CURSO]

AS
BEGIN   
  SELECT *
  FROM [dbo].[Curso]
END
go

CREATE TABLE [dbo].[Aluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Cpf] [nvarchar](11) NOT NULL,
	[CursoId] [int] NOT NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[PROC_INCLUIR_ALUNO]
@Nome VARCHAR(100) = NULL,
@Cpf VARCHAR(11) = NULL,
@CursoId int = NULL
AS
BEGIN   
if not exists(select * from Aluno where Cpf = @Cpf)
	BEGIN
		INSERT INTO [dbo].[Aluno]
           (Nome
           ,Cpf
           ,CursoId)
     VALUES
           (@Nome
           ,@Cpf
           ,@CursoId)
	END  
END
go

CREATE PROCEDURE [dbo].[PROC_EDITAR_ALUNO]
@Id INT = NULL,
@Nome VARCHAR(100) = NULL,
@Cpf VARCHAR(11) = NULL,
@CursoId int = NULL
AS
BEGIN   
  UPDATE [dbo].[Aluno]
   SET Nome = @Nome
      ,Cpf = @Cpf
      ,CursoId = @CursoId
 WHERE Id = @Id
END
go


CREATE PROCEDURE [dbo].[PROC_BUSCAR_ALUNO]

AS
BEGIN   
  SELECT *
  FROM [dbo].[Aluno]
END
go

CREATE TABLE [dbo].[Nota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CursoId] [int] NOT NULL,
	[AlunoId] [int] NOT NULL,
	[Bimestre] [int] NOT NULL,
	[Nota] [int] NOT NULL
 CONSTRAINT [PK_Nota] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[PROC_INCLUIR_NOTA]
@CursoId int = NULL,
@AlunoId int = NULL,
@Bimestre int = NULL,
@Nota  int
AS
BEGIN  
if not exists (select * from Nota where CursoId = @CursoId and AlunoId = @AlunoId and Bimestre = @Bimestre)
	BEGIN
		INSERT INTO [dbo].[Nota]
           (CursoId
           ,AlunoId
           ,Bimestre
		   ,Nota)
     VALUES
           (@CursoId
           ,@AlunoId
           ,@Bimestre
		   ,@Nota
		   )
	END  
END
go	

CREATE PROCEDURE [dbo].[PROC_EDITAR_NOTA]
@Id INT = NULL,
@Nota INT = NULL
AS
BEGIN   
  UPDATE [dbo].[Nota]
   SET Nota = @Nota
 WHERE Id = @Id
END
go


CREATE PROCEDURE [dbo].[PROC_BUSCAR_NOTAS]

AS
BEGIN   
  SELECT *
  FROM [dbo].[Nota]
END
go