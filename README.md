# Blazor WebAssembly Prometheus Example
Example of a docker composed Blazor WebAssembly application that includes support for both Prometheus and Grafana.

## Quick start

### Prerequisites
- Visual Studio 2022

### Build & Run 

1. Open BlazorWebAssemblyPrometheusExample.sln
2. Run the "docker-compose" project

### Links
- The Blazor application can be found at [http://localhost:4200/](http://localhost:4200/)
- Prometheus can be found at [http://localhost:9090/](http://localhost:9090/)
- Grafana can be found at [http://localhost:3000/](http://localhost:3000/)

### Setup Grafana with the test dashboard
1. Open Grafana
2. Login into Grafana by using "admin" for both the username and password
3. Enter a new password
4. Go to Dashboards -> New -> Import
5. Upload the JSON file called "[GrafanaTestDashboard1.json](GrafanaTestDashboard1.json)"
6. Select "Prometheus" as the data source