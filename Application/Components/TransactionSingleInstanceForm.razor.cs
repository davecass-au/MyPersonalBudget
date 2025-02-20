using Microsoft.AspNetCore.Components;
using Shared.Models.DTOs;

namespace Application.Components
{
	public partial class TransactionSingleInstanceForm
	{
        [Parameter]
        public EventCallback<bool> FormClosed { get; set; }

        [Parameter]
        public int TransactionId { get; set; }

        readonly TransactionSingleInstanceDto singleInstance = new();


        async Task Submit(TransactionSingleInstanceDto singleInstance)
        {
            // TODO: could be better - check on initialized and set then
            if (TransactionId > 0)
            {
                singleInstance.TransactionId = TransactionId;
                await FormClosed.InvokeAsync((await dataService.TransactionSingleInstances.Add(singleInstance)) > 0);
            }
        }

        async Task Cancel()
        {
            await FormClosed.InvokeAsync(false);
        }
    }
}