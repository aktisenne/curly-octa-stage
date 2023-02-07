SELECT p.name, c.name
FROM products p
LEFT JOIN categories c
ON p.category_id = c.id