using System.Collections;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float forceMultiplier = 12f; // Força aplicada no movimento
    public float velocidadeMaxima = 10f; // Velocidade máxima de movimento
    
    private bool _estrelaAtiva;
    
    private Coroutine _rotinaCrescimento;
    private Coroutine _rotinaEstrela;

    private Rigidbody _rb; // cache

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        if (_rb.linearVelocity.magnitude <= velocidadeMaxima)
        {
            _rb.AddForce(new Vector3(horizontalInput * forceMultiplier, 0, 0));    
        }
    }

    public void AtivarCrescimentoTemporario(float duracao)
    {
        if (_rotinaCrescimento != null) StopCoroutine(_rotinaCrescimento);
        _rotinaCrescimento = StartCoroutine(CrescerTemporariamente(duracao));
    }

    private IEnumerator CrescerTemporariamente(float duracao)
    {
        Vector3 tamanhoOriginal = transform.localScale;
        transform.localScale = tamanhoOriginal * 2f;
        
        yield return new WaitForSeconds(duracao);
        
        transform.localScale = tamanhoOriginal;
        _rotinaCrescimento = null;
    }
    
    public void AtivarEstrela(float duracaoEmSegundos)
    {
        if (_rotinaEstrela != null) StopCoroutine(_rotinaEstrela);
        _rotinaEstrela = StartCoroutine(EstrelaTemporaria(duracaoEmSegundos));
    }

    private IEnumerator EstrelaTemporaria(float duracaoEmSegundos)
    {
        _estrelaAtiva = true;

        yield return new WaitForSeconds(duracaoEmSegundos);

        _estrelaAtiva = false;
        _rotinaEstrela = null;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (_estrelaAtiva)
        {
            if (collision.gameObject.CompareTag("Perigo"))
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Perigo"))
            {
                Destroy(gameObject);
            }
        }
    }
}