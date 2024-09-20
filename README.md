
# FilmTest
(О выполнении ниже)

Тестовое задание:
Разработать MAUI (Либо Xamarin.Forms) мобильное приложение для поиска и отображения информации о кинофильмах. Приложение должно позволять искать кинофильмы по одному или нескольким критериям и отображать информацию по выбранному кинофильму. Функциональные требования 

• Каждый кинофильм должен быть связан с одним или несколькими актерами. Поиск фильма должен осуществляться по названию, жанру или по имени одного из актеров. Результат поиска необходимо отображать на той же странице ниже поисковой формы. 

• Приложение должно быть написано на MAUI (Либо Xamarin.Forms) под две платформы: iOS и Android 

• Использовать паттерн MVVM либо производные от него. 

• Данные необходимо хранить в локальной SQLite базе данных. 

• Использование Entity Framework в качестве ORM будет плюсом, но не является обязательным. 

• Код должен быть написан в едином стиле и содержать минимальные комментарии. 

• Наличие тестов будет плюсом. 

• Наличие документации по описанию функционала и порядку развертывания.

# Выполнение

В работе использовались MAUI MVVM SQLite. Из доп пакетов Entity Framework Core, Entity Framework Core SQLite, SQlite, ToolKit.   
Прилагается архив со всеми выходными данными. MAUI кроссплатформа данное приложение разработано на Android и Windows, предположительно и на iOS должно будет запустится. 

Сначала разбор используемой базы данных Films: 


![изображение](https://github.com/Gladn/FilmTest/assets/92585647/cfc8199f-1f7d-47e5-9c49-557b7149def7)


Прилагается sql файл, но с EF Core база данных будет создаваться на устройстве автоматически по расположению FileSystem.AppDataDirectory. Поиск работает по 3 критериям фильм, жанр и актер.
 
**Функционал:** 

• Кнопка "Загрузить базу" по нажатию создает: базу данных Films, таблицы и данные для этих таблиц. 

• Первое поле ввода фильтрует фильмы по критерию название фильма (без учета регистра)

• Расширитель открывает возможность поиска по нескольким критериям

• Сборщик содержит все жанры фильмов, можно выбрать нужный жанр (у каждого фильма 1+ жанров)

• Второе поле ввода фильтрует по имени актера (с учетом регистра, каждый фильм 3+ актера)

• Нажатие на фильм открывает страницу с подробной информацией 

.

![ScreenShot_6](https://github.com/Gladn/FilmTest/assets/92585647/fac769e7-eca3-48cb-9fdd-2e84eb7e3c60)


Чтобы посмотреть актеров/жанры фильма нужно нажать на конкретный фильм в списке


.


![Screenshot_9](https://github.com/Gladn/FilmTest/assets/92585647/af6d4078-20ea-4d31-b36c-fd11035e30e6)



# Порядок развертывания

**Скачать и установить Films.apk**



Пример использования на физическом android 13


![Screenshot_10](https://github.com/Gladn/FilmTest/assets/92585647/ac35d822-8ce6-4e2a-b267-07554f74b571)



# Пометки 
1) Вынести бизнес-логику в отдельный слой (создал слой Service)
2) Вью-модель не должна знать о бизнес-сущностях и существовании дата-контекста (Дата контекст вынес в Service, бизнес сущности разделил с использованием DTOs (Data Transfer Object))
3) View не должны знать о слоях ниже вью-модели (нужно будет исправить с помощью ViewModel)
4) Отдельно предоставить SQL-запрос поиска, в само приложение не встраивать (Сделал так же в приложении, но сделал отдельный sql запрос)


![изображение](https://github.com/Gladn/FilmTest/assets/92585647/79457da6-bd79-4bca-a0a3-1aff2adc3154)

