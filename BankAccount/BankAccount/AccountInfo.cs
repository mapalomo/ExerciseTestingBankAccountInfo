﻿using Bank;
using System.Threading.Tasks;

public class AccountInfo
{
    private readonly int _accountId;
    private readonly IAccountService _accountService;
    public AccountInfo(int accountId, IAccountService accountService)
    {
        _accountId = accountId;
        _accountService = accountService;
    }
    public double Amount { get; private set; }
    public void RefreshAmount()
    {
        Amount = _accountService.GetAccountAmount(_accountId);
    }
    public async Task RefreshAmountAsync()
    {
        Amount = await _accountService.GetAccountAmountAsync(_accountId);
    }
}