﻿using Communications.Application.BaseMethods;
using Communications.Core.Models;
using MediatR;

namespace Communications.Application.Classifications.Queries;

public class GetClassificationByIdQuery : BaseGetByIdQuery<Classification>
{
}