CREATE TABLE IF NOT EXISTS Notes(
Id INTEGER primary key autoincrement,
Body TEXT NOT NULL,
TodoItemId INTEGER NOT NULL,
FOREIGN KEY (TodoItemId)
REFERENCES TodoItems (Id)
ON UPDATE CASCADE
ON DELETE SET NULL
);

CREATE TABLE IF NOT EXISTS Priorities(
Id INTEGER PRIMARY KEY AUTOINCREMENT,
Title TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Users(
Id INTEGER PRIMARY KEY AUTOINCREMENT,
Username TEXT NOT NULL,
Email TEXT NOT NULL UNIQUE,
Password TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS TodoLists(
Id INTEGER PRIMARY KEY AUTOINCREMENT,
Title TEXT NOT NULL,
CreationDate TEXT NOT NULL,
UserId INTEGER NOT NULL,
FOREIGN KEY (UserId)
	REFERENCES Users (Id)
		ON UPDATE CASCADE
		ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS TodoItems(
Id INTEGER PRIMARY KEY AUTOINCREMENT,
Title TEXT NOT NULL,
IsFinished TINYINT NOT NULL CHECK (IsFinished IN (0,1)),
DeadlineDate TEXT,
PriorityId INTEGER,
NoteId INTEGER,
TodoListId INTEGER NOT NULL,
FOREIGN KEY (PriorityId)
	REFERENCES Priorities (Id)
		ON UPDATE CASCADE
		ON DELETE RESTRICT,
FOREIGN KEY (NoteId)
	REFERENCES Notes (Id)
		ON UPDATE RESTRICT
		ON DELETE SET NULL,
FOREIGN KEY (TodoListId)
	REFERENCES TodoLists (Id)
		ON UPDATE RESTRICT
		ON DELETE CASCADE
);