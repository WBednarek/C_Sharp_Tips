    //Yeah, the code could be better designed, but it well describes this case.
    
    private async void doPromgammeFunctionality() //Might be async Task as well
    {
        settingIUBeforedownloadSQLData();
        await executeSearchingAsync(); //Witout this await programme would continue on UI thread invoking moreStuffDoneOnUI() and revertingUIAfterDownloadSQLData()
        //in the same time as executeSearchingAsync() and it will not wait until executeSearchingAsync() finishes.
        //We definitely do not want it, since here interface update is connected with what executeSearchingAsync() does.
        moreStuffDoneOnUI();
        revertingUIAfterDownloadSQLData();
    }

    private async Task downloadSQLDataAsync()
    {
        var first = await getSQLDataAsync(firstData, secondData); //This await and one below only assures that it will wait for what getSQLDataAsync()
        //returns only inside downloadSQLDataAsync() function.
        //So it waits until getSQLDataAsync() is finished then run the rest of the code here - updateInterface();
        //However if you wouldn’t do await inside doPromgammeFunctionality() it would continue moreStuffDoneOnUI() and revertingUIAfterDownloadSQLData() 
        //paralelly to getSQLDataAsync(). and here we would like to wait until getSQLDataAsync() finishes. 

        //Summarizing of you want to wait for results from getSQLDataAsync() you have put await in internal (downloadSQLDataAsync()) and outer (doPromgammeFunctionality()) functions.
        var second = await getSQLDataAsync(firstData, secondData);
        updateInterface(first); //normally for a better design this should be outside this method
        updateInterface(second);
    }

    private Task<SQLData> PerformSearchAsync(Type1 selectedServer, List<string> secondData)
    {
        return Task.Run(() => getSQLData(firstData, secondData)); //getSQLData() is a standard function
    }
