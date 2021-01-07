import pandas as pd
dates = pd.date_range(start='2020-01-01', end='2020-01-31', freq='d').to_list()
numbers = [43, 3, 31, 1, 39, 18, 15, 49, 6, 14, 46, 45, 15, 13, 5, 4, 23, 25, 43, 4, 18, 3, 27, 38, 43, 38, 45, 39, 19, 30, 50]
df = pd.DataFrame({'Dates':dates, 'Price':numbers})
print(df.head())

df['Rolling'] = df['Price'].rolling(5).mean()
print(df.head(31))