USE [AlhadiLibrary];
GO
INSERT INTO AspNetRoles (Name, NormalizedName)
VALUES
(N'Admin', N'ADMIN'),
(N'Author', N'AUTHOR'),
(N'Translator', N'TRANSLATOR'),
(N'User', N'USER');

SET IDENTITY_INSERT Users ON;

INSERT INTO Users
(Id, CreatedAt, IsDeleted, FirstName, LastName, Email, MobileNumber, Balance,
 IdentityUserId, Role, UserName, NormalizedUserName, NormalizedEmail,
 EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
VALUES
(1, GETDATE(), 0, N'مدیر', N'سیستم', N'admin@lib.com', '09120000001', 0,
 1, 1, 'admin', 'ADMIN', 'ADMIN@LIB.COM', 1, 1, 0, 0, 0),

(2, GETDATE(), 0, N'علی', N'احمدی', N'ali@author.com', '09120000002', 0,
 2, 2, 'ali', 'ALI', 'ALI@AUTHOR.COM', 1, 1, 0, 0, 0),

(3, GETDATE(), 0, N'مریم', N'کریمی', N'maryam@translator.com', '09120000003', 0,
 3, 3, 'maryam', 'MARYAM', 'MARYAM@TRANSLATOR.COM', 1, 1, 0, 0, 0),

(4, GETDATE(), 0, N'رضا', N'محمدی', N'user@lib.com', '09120000004', 0,
 4, 4, 'reza', 'REZA', 'USER@LIB.COM', 1, 1, 0, 0, 0);

SET IDENTITY_INSERT Users OFF;


INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES
(1, 1), -- Admin
(2, 2), -- Author
(3, 3), -- Translator
(4, 4); -- User

INSERT INTO Categories
(Title, IsActive, CreatedAt, IsDeleted)
VALUES
(N'رمان', 1, GETDATE(), 0),
(N'فلسفه', 1, GETDATE(), 0),
(N'تاریخی', 1, GETDATE(), 0);

INSERT INTO Books
(Title, Price, PageCount, ImagePath, CategoryId, CreatedAt, IsDeleted)
VALUES
(N'جنایت و مکافات', 250000, 480, N'/images/books/jenayat.jpg', 1, GETDATE(), 0),
(N'دنیای سوفی', 180000, 350, N'/images/books/sofi.jpg', 2, GETDATE(), 0),
(N'تاریخ ایران', 300000, 520, N'/images/books/iran.jpg', 3, GETDATE(), 0);

INSERT INTO BookAuthors
(BookId, AuthorId, CreatedAt, IsDeleted)
VALUES
(1, 2, GETDATE(), 0),
(2, 2, GETDATE(), 0),
(3, 2, GETDATE(), 0);


INSERT INTO BookTranslators
(BookId, TranslatorId, CreatedAt, IsDeleted)
VALUES
(1, 3, GETDATE(), 0),
(2, 3, GETDATE(), 0);


INSERT INTO Comments
(Title, Text, Rating, IsApproved, BookId, UserId, CreatedAt, IsDeleted)
VALUES
(N'عالی', N'کتاب فوق‌العاده‌ای بود', 5, 1, 1, 4, GETDATE(), 0),
(N'خوب', N'محتوای آموزنده داشت', 4, 1, 2, 4, GETDATE(), 0),
(N'معمولی', N'می‌توانست بهتر باشد', 3, 1, 3, 4, GETDATE(), 0);
