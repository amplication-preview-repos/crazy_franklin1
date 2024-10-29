using Microsoft.AspNetCore.Mvc;
using WhatsAppBotService.APIs.Common;
using WhatsAppBotService.Infrastructure.Models;

namespace WhatsAppBotService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class UserFindManyArgs : FindManyInput<User, UserWhereInput> { }
