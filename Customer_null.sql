use Customer_Order
select CUSTOMER.Name from ORDERS
full outer join CUSTOMER on ORDERS.CUDTOMER_ID=CUSTOMER.ID
where AMOUNT is null
