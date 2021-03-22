# Payments-bot

Payments-bot is a pet-project that was made for self-usage.

# Functionality

Handles Telegram requests.
Gets an information about the balance and transactions of your
credit card from PrivatBank and shows it in Telegram.



# How To

Create a Telegram bot using this tutorial https://core.telegram.org/bots;
Add these commands via BotFather : add, delete, merchants;

Create a merchant account via Privat24 using this tutorial https://api.privatbank.ua/#p24/registration. Make sure that you disabled all payment features and your merchant account can be used only for informational operations.
Make sure that you entered correct IP address of your web server (where app would be deployed);

Fill in "BotToken" and "AppUrl" fields (Models/AppConfing.cs).
Make sure that the database connection string is correct (appsettings.json);

Run the application ;

Start conversation with your bot in Telegram and select the /add command;

Tap the link and fill in the merchant form;

After successfull registrartion go back to the bot and select the /merchants command;

Enjoy !
