<div align="center">
    <h1>Trabalho Prático</h1>
    <h2>Motor de Busca em Documentos</h2>
    <h3>com Algoritmos de Substring Search e Observabilidade</h3>
    <p>Algoritmos Avançados</p>
</div>

---

Aplicação web desenvolvida para a disciplina de Algoritmos Avançados com o objetivo de realizar buscas de palavras e trechos em documentos TXT utilizando diferentes algoritmos de substring search. O projeto permite comparar algoritmos de busca em tempo de execução, visualizar métricas de desempenho e monitorar a aplicação utilizando OpenTelemetry, Prometheus e Grafana.

---

## Tecnologias Utilizadas
### Backend
- C#
- ASP.NET Core Web API
- OpenTelemetry
- xUnit
### Frontend
- React
- Vite
- Axios
### Observabilidade
- Docker
- Grafana
- Prometheus
- Tempo
- OTEL Collector

---

## Executando o Backend
- cd backend
- dotnet restore
- dotnet run

---

## Executando o Frontend
- cd frontend
- npm install
- npm run dev

---

## Executando os Testes
- cd tests
- dotnet test

---

## Executando o Dashboard
- cd observability
- docker compose up -d
