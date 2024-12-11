FROM node:23 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY RideoutUI .
RUN npm run build --prod

FROM nginx:alpine
COPY --from=build /app/dist/RideoutUI /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]