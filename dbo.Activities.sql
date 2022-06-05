CREATE TABLE [dbo].[Activities] (
    [ActivityId]  NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Date]        DATETIME       NOT NULL,
    [StartTime]   DATETIME       NOT NULL,
    [EndTime]     DATETIME       NOT NULL,
    [StudentId]   INT            NOT NULL,
    [Coursecode]  INT             NOT NULL,
    CONSTRAINT [PK_dbo.Activities] PRIMARY KEY CLUSTERED ([ActivityId] ASC),
    CONSTRAINT [FK_dbo.Activities_dbo.Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([StudentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Activities_dbo.Courses_Coursecode] FOREIGN KEY ([Coursecode]) REFERENCES [dbo].[Courses] ([CourseCode]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StudentId]
    ON [dbo].[Activities]([StudentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Coursecode]
    ON [dbo].[Activities]([Coursecode] ASC);

