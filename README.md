Сделать asp.net web api 2 контроллера для редактирования таблиц пациентов и врачей.
Контрлллер должен поддерживать операции:
1. Добавление записи
2. Редактирование записи
3. Удаление записи
4. Получения списка записей для формы списка с поддержкой сортировки и постраничного возврата данных (должна быть возможность через параметры указать по какому полю список должен быть отсортирован и так же через параметры указать какой фрагмент списка (страницу) необходимо вернуть)
5. Получение записи по ид для редактирования

Объект, возвращаемый методом получения записи для редактирования и объекты, возвращаемые методом получения списка должны быть разными:
объект для редактирования должен содержать только ссылки (id) связанных записей из других таблиц,
объект списка не должен содержать внещних ссылок, вместо них необходимо возвращать значение из связанной таблицы (т.е. не id специализации врача, а название).
Никаких лишних полей в объектах быть не должно.

В качестве базы необходимо использовать MS SQL.
Таблицы в базе:
1. Участки (Номер)
2. Специализаци (Название)
3. Кабинеты (Номер)
4. Пациенты (Фамилия, Имя, Отчество, Адрес, Дата рождения, Пол, Участок (ссылка))
5. Врачи (ФИО, Кабинет (ссылка), Специализация (ссылка), Участок (для участковых врачей, ссылка))
