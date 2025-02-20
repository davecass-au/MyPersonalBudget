using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;
using Shared.Models.Enums;

namespace Application.Components
{
	public partial class TransactionRecurringInstanceForm
	{
        [Parameter]
        public EventCallback<bool> FormClosed { get; set; }

        [Parameter]
        public int TransactionId { get; set; }

        readonly TransactionRecurringInstanceDto recurringInstance = new();

     
        async Task Submit(TransactionRecurringInstanceDto recurringInstance)
        {
            // TODO: could be better - check on initialized and set then
            if (TransactionId > 0)
            {
                recurringInstance.TransactionId = TransactionId;
                await FormClosed.InvokeAsync((await dataService.TransactionRecurringInstances.Add(recurringInstance)) > 0);
            }
        }

        async Task Cancel()
        {
            await FormClosed.InvokeAsync(false);
        }
    }
}