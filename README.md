# Kursovay
на базе Secret0-OchkA/DockerDB  
Клиента можно сгенерировать в Docker вот этой командой
```
docker run --rm \
  -v ${PWD}:/local openapitools/openapi-generator-cli generate \
  -i /local/path/to/apiSchema.json \
  -g <lang> \
  -o /local/path/to/out/folder \
  --additional-properties pubName=<clientName>
```
<code>[языки для которых можно сгенерировать клиент](https://openapi-generator.tech/docs/generators)</code>

