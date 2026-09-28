# TechsoftAI API V3.0
ASP.NET Core 8 backend for IIS.

Initial endpoints:
- GET /api/health
- GET /api/whatsapp/webhook (Meta verification)
- POST /api/whatsapp/webhook (incoming webhook receiver)

Do not commit real SQL passwords, WhatsApp access tokens, VAPID private keys, or AI API keys.

IIS server prerequisites:
1. .NET 8 Hosting Bundle
2. HTTPS certificate/domain
3. Publish this project and point an IIS Application Pool (No Managed Code) to the publish folder.
4. Put production secrets in server environment variables or a non-repository production configuration.
