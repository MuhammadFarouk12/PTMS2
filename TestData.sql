INSERT INTO `quiz` (`quiz_name`) 
VALUES 
('English Grammar'),
('English Vocabulary'),
('English Literature');
-----------
INSERT INTO `question` (`text`, `quiz_id`) 
VALUES 
-- English Grammar Quiz
('Which of the following is a correct sentence?', 1),
('What is the past tense of the verb "go"?', 1),
('Which word is a preposition?', 1),

-- English Vocabulary Quiz
('What is the meaning of the word "benevolent"?', 2),
('Which of these is a synonym for "happy"?', 2),
('What does "ubiquitous" mean?', 2),

-- English Literature Quiz
('Who wrote "Romeo and Juliet"?', 3),
('What is the title of the famous work by George Orwell about totalitarianism?', 3),
('Who is the author of "The Catcher in the Rye"?', 3);

-------------

INSERT INTO `choice` (`text`, `is_true`, `ques_id`) 
VALUES 
-- English Grammar Quiz
('I has a dog.', 0, 1),
('I have a dog.', 1, 1),
('I haves a dog.', 0, 1),
('I had dog.', 0, 1),

('goed', 0, 2),
('went', 1, 2),
('goes', 0, 2),
('gone', 0, 2),

('in', 1, 3),
('quickly', 0, 3),
('happy', 0, 3),
('slowly', 0, 3),

-- English Vocabulary Quiz
('Kind-hearted', 1, 4),
('Selfish', 0, 4),
('Angry', 0, 4),
('Mean', 0, 4),

('Sad', 0, 5),
('Joyful', 1, 5),
('Angry', 0, 5),
('Indifferent', 0, 5),
----------------------



-- Assuming student IDs, quiz IDs, and level IDs are already in the system
-- Example student IDs: 1, 2, 3
-- Example quiz IDs: 1, 2, 3
-- Example level IDs: 1, 2, 3
INSERT INTO `examination` (`student_id`, `quiz_id`, `final_mark`, `start_time`, `end_time`, `level_id`) 
VALUES
-- Student 1, Quiz 1, Level 1
(1, 1, 85.50, '2025-09-20 10:00:00', '2025-09-20 10:45:00', 1),

-- Student 2, Quiz 2, Level 2
(2, 2, 92.00, '2025-09-20 11:00:00', '2025-09-20 11:45:00', 2),

-- Student 3, Quiz 3, Level 3
(3, 3, 78.25, '2025-09-20 12:00:00', '2025-09-20 12:45:00', 3),

-- Student 1, Quiz 2, Level 1
(1, 2, 88.00, '2025-09-21 14:00:00', '2025-09-21 14:45:00', 1),

-- Student 2, Quiz 3, Level 2
(2, 3, 75.50, '2025-09-21 15:00:00', '2025-09-21 15:45:00', 2),

-- Student 3, Quiz 1, Level 3
(3, 1, 90.00, '2025-09-21 16:00:00', '2025-09-21 16:45:00', 3),

-- Student 1, Quiz 3, Level 1
(1, 3, 70.00, '2025-09-22 10:00:00', '2025-09-22 10:45:00', 1),

-- Student 2, Quiz 1, Level 2
(2, 1, 80.50, '2025-09-22 11:00:00', '2025-09-22 11:45:00', 2),

-- Student 3, Quiz 2, Level 3
(3, 2, 65.75, '2025-09-22 12:00:00', '2025-09-22 12:45:00', 3);

INSERT INTO `level` (`level_name`, `level_order`, `level_lock`) 
VALUES
-- Level 1: Beginner level
('Beginner', 1, 0),

-- Level 2: Intermediate level
('Intermediate', 2, 0),

-- Level 3: Advanced level
('Advanced', 3, 0),

-- Level 4: Expert level (optional for extra difficulty)
('Expert', 4, 1),

-- Level 5: Master level (locked level, harder exams)
('Master', 5, 1);
('Omnipresent', 0, 6),
('Everywhere', 1, 6),
('Rare', 0, 6),
('Hidden', 0, 6),

-- English Literature Quiz
('William Shakespeare', 1, 7),
('Jane Austen', 0, 7),
('Charles Dickens', 0, 7),
('Mark Twain', 0, 7),

('1984', 1, 8),
('Brave New World', 0, 8),
('The Handmaid\'s Tale', 0, 8),
('Fahrenheit 451', 0, 8),

('J.D. Salinger', 1, 9),
('Ernest Hemingway', 0, 9),
('F. Scott Fitzgerald', 0, 9),
('John Steinbeck', 0, 9);

---------------


