SELECT Customer.Date as Date, AVG(Item.ItemPrice * tblOrderItem.quantity) as AmtSpent, SUM(Item.ItemPrice * tblOrderItem.quantity) as AmtTotal, COUNT(tblOrderItem.tblOrderID) as NoOfOrders FROM Customer
INNER JOIN TableOrder ON Customer.CustID = TableOrder.CustId
INNER JOIN tblOrderItem ON TableOrder.orderId = tblOrderItem.tblOrderID
INNER JOIN Item ON tblOrderItem.tblItemID = Item.ItemID
WHERE Customer.Date = '2022-05-25'
GROUP BY Customer.Date;