FROM node:carbon

# Создать директорию app
WORKDIR /app

# Установить зависимости приложения
RUN npm -g install serve

# Используется символ подстановки для копирования как package.json, так и package-lock.json
COPY package*.json ./

RUN npm install

# Скопировать исходники приложения
COPY src /app/src

# Собрать статические файлы vue
RUN npm run build

EXPOSE 8080
# Запуск сервера в директории dist на порту 8080
CMD ["serve", "-s", "dist", "-p", "8080"]