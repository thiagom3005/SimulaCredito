--Listar todos os clientes do estado de SP que possuem mais de 60% das parcelas pagas
SELECT C.Id AS ClienteId,
       C.Nome,
       C.CPF,
       C.UF,
       F.Id AS FinanciamentoId,
       COUNT(P.Id)
FROM Cliente C
INNER JOIN Financiamento F ON (F.ClienteId = C.Id)
INNER JOIN Parcela P ON (P.FinanciamentoId = P.Id)
WHERE C.UF = 'SP'
  AND P.DataPagamento IS NOT NULL
GROUP BY C.Id,
         C.Nome,
         C.CPF,
         C.UF,
         F.Id
HAVING ((COUNT(P.Id) * 100) /
          (SELECT COUNT(P2.Id)
           FROM Parcela P2
           WHERE P2.FinanciamentoId = F.Id)) > 60

--Listar os primeiros quatro clientes que possuem alguma parcela com mais de cinco dias em atraso (Data Vencimento maior que data atual E data pagamento nula)
SELECT DISTINCT top 4 C.Id AS ClienteId,
                    C.Nome,
                    C.CPF,
                    C.UF
FROM Cliente C
INNER JOIN Financiamento F ON (F.ClienteId = C.Id)
WHERE EXISTS
    (SELECT 1
     FROM Parcela P
     WHERE P.FinanciamentoId = F.Id
       AND P.DataPagamento IS NULL
       AND P.DataVencimento < DATEADD(DAY, -5, GETDATE()))