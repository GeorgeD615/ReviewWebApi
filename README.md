<h1>Reviews API на ASP.NET</h1>

<h2>Описание</h2>
<p>
    Этот проект представляет собой Web API, разработанный на ASP.NET Core для управления отзывами пользователей о товарах.
    API предоставляет возможность создавать, удалять и получать отзывы. В качестве базы данных
    используется Microsoft SQL Server.
</p>
<p>
    Данное Web API используется в ASP.NET MVC приложении по доставке еды. Ознакомиться с ним можно <a href="https://github.com/GeorgeD615/DeliveryWebApp" target="_blank">здесь</a>. 
</p>

<h2>Функционал</h2>
<p>Основные возможности API:</p>
<ul>
    <li>Получение отзыва по ID</li>
    <li>Получение списка отзывов по ID товара</li>
    <li>Создание нового отзыва</li>
    <li>Удаление отзыва по ID</li>
    <li>Удаление отзывов по ID пользователя</li>
</ul>

<h2>Требования</h2>
<p>Для развёртывания проекта убедитесь, что у вас установлен и запущен docker-engine:</p>
<ul>
    <li><a href="https://www.docker.com/get-started" target="_blank">Docker</a></li>
</ul>

<h2>Установка</h2>

<h3>Шаг 1: Клонирование репозитория</h3>
<pre><code>git clone https://github.com/GeorgeD615/ReviewWebApi.git
cd ReviewWebApi
</code></pre>

<h3>Шаг 2: Запуск с использованием Docker Compose</h3>
<p>Запустите сервисы с помощью команды:</p>
<pre><code>docker-compose up -d
</code></pre>
    <p>Это развернет два контейнера:</p>
    <ul>
        <li><code>mssqlserver</code> — контейнер с SQL Server</li>
        <li><code>reviewsapi</code> — контейнер с вашим API</li>
    </ul>
    <p>Приложение будет доступно по адресу <a href="http://localhost:5001" target="_blank">http://localhost:5001</a>.</p>

<p>Докер образ приложения размещён <a href="https://hub.docker.com/r/georged615/reviews_api" target="_blank">здесь</a>.</p>

<h2>Примеры использования</h2>

<h3>Получение отзывов по ID продукта</h3>
<pre><code>curl -X 'GET' \
  'http://localhost:5001/Review/GetByProductId?productId=3fa85f64-5717-4562-b3fc-2c963f66afa6' \
  -H 'accept: text/plain'
</code></pre>
<p>Пример ответа:</p>
<pre><code>[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "text": "Отличный товар",
    "grade": 5,
    "date": "2024-09-19"
  }
]
</code></pre>

<h3>Получение отзыва по ID</h3>
<pre><code>curl -X 'GET' \
  'http://localhost:5001/Review/GetById?id=3fa85f64-5717-4562-b3fc-2c963f66afa6' \
  -H 'accept: text/plain'
</code></pre>
<p>Пример ответа:</p>
<pre><code>{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "text": "Отличный товар",
  "grade": 5,
  "date": "2024-09-19"
}
</code></pre>

<h3>Создание нового отзыва</h3>
<pre><code>curl -X 'POST' \
  'http://localhost:5001/Review/Create' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "text": "Отличный товар",
  "grade": 5
}'
</code></pre>

<h3>Удаление отзыва по ID</h3>
<pre><code>curl -X 'DELETE' \
  'http://localhost:5001/Review/DeleteById?id=3fa85f64-5717-4562-b3fc-2c963f66afa6' \
  -H 'accept: */*'
</code></pre>

<h3>Удаление отзывов по ID пользователя</h3>
<pre><code>curl -X 'DELETE' \
  'http://localhost:5001/Review/DeleteByUserId?userId=3fa85f64-5717-4562-b3fc-2c963f66afa6' \
  -H 'accept: */*'
</code></pre>

<h2>Документация API</h2>
<p>Для тестирования и просмотра документации API используется <a href="https://swagger.io/" target="_blank">Swagger</a>.</p>
<p>После запуска приложения Swagger будет доступен по адресу:</p>
<pre><code>http://localhost:5001/swagger/index.html
</code></pre>
