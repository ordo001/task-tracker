-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Дек 12 2024 г., 21:39
-- Версия сервера: 8.0.30
-- Версия PHP: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `task-Tracker_DB`
--

-- --------------------------------------------------------

--
-- Структура таблицы `cards`
--

CREATE TABLE `cards` (
  `id_card` int NOT NULL,
  `name_card` varchar(30) NOT NULL,
  `heading` varchar(30) NOT NULL,
  `content` varchar(700) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `id_user` int DEFAULT NULL,
  `id_section` int NOT NULL,
  `cardLocation_Y` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `sections`
--

CREATE TABLE `sections` (
  `id_section` int NOT NULL,
  `id_work_space` int NOT NULL,
  `name_section` varchar(30) NOT NULL,
  `heading_section` varchar(30) NOT NULL,
  `sectionLocation_X` int NOT NULL,
  `sectionLocation_Y` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `sections`
--

INSERT INTO `sections` (`id_section`, `id_work_space`, `name_section`, `heading_section`, `sectionLocation_X`, `sectionLocation_Y`) VALUES
(6, 1, 'section0', 'Новая секция', 10, 140),
(7, 2, 'section0', 'Новая секция', 10, 140),
(8, 3, 'section0', 'Новая секция', 10, 140),
(9, 3, 'section8', 'Новая секция', 470, 140),
(10, 2, 'section7', 'Новая секция', 470, 140);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id_user` int NOT NULL,
  `login` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `role` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'Default',
  `name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id_user`, `login`, `password`, `role`, `name`) VALUES
(1, 'test', 'test', 'Default', 'testName'),
(3, 'aboba', '123', 'Default', 'abobaName'),
(4, 'test2', 'test2', 'Default', 'testName'),
(5, 'admin', 'admin', 'Administrator', 'DungeonMaster');

-- --------------------------------------------------------

--
-- Структура таблицы `user_work_space`
--

CREATE TABLE `user_work_space` (
  `user_id` int NOT NULL,
  `work_space_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `user_work_space`
--

INSERT INTO `user_work_space` (`user_id`, `work_space_id`) VALUES
(1, 1),
(3, 1),
(4, 1),
(1, 2);

-- --------------------------------------------------------

--
-- Структура таблицы `work_spaces`
--

CREATE TABLE `work_spaces` (
  `id_work_space` int NOT NULL,
  `work_space_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `work_spaces`
--

INSERT INTO `work_spaces` (`id_work_space`, `work_space_name`) VALUES
(1, 'Информационные технологии'),
(2, 'Тестовое пространство 1'),
(3, 'Тестовое пространство 2');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `cards`
--
ALTER TABLE `cards`
  ADD PRIMARY KEY (`id_card`),
  ADD KEY `id_section` (`id_section`),
  ADD KEY `id_user` (`id_user`);

--
-- Индексы таблицы `sections`
--
ALTER TABLE `sections`
  ADD PRIMARY KEY (`id_section`),
  ADD KEY `id_work_space` (`id_work_space`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id_user`);

--
-- Индексы таблицы `user_work_space`
--
ALTER TABLE `user_work_space`
  ADD PRIMARY KEY (`user_id`,`work_space_id`),
  ADD KEY `work_space_id` (`work_space_id`);

--
-- Индексы таблицы `work_spaces`
--
ALTER TABLE `work_spaces`
  ADD PRIMARY KEY (`id_work_space`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `cards`
--
ALTER TABLE `cards`
  MODIFY `id_card` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `sections`
--
ALTER TABLE `sections`
  MODIFY `id_section` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id_user` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `work_spaces`
--
ALTER TABLE `work_spaces`
  MODIFY `id_work_space` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `sections`
--
ALTER TABLE `sections`
  ADD CONSTRAINT `sections_ibfk_1` FOREIGN KEY (`id_work_space`) REFERENCES `work_spaces` (`id_work_space`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `user_work_space`
--
ALTER TABLE `user_work_space`
  ADD CONSTRAINT `user_work_space_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id_user`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_work_space_ibfk_2` FOREIGN KEY (`work_space_id`) REFERENCES `work_spaces` (`id_work_space`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
