using System;
using Unity.VisualScripting;
using UnityEngine;

public class StoveCounter : BaseCounter, IHasProgress
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;
    [SerializeField] private BurningRecipeSO[] burningRecipeSOArray;

    private float fryingTimer;
    private float burningTimer;
    private FryingRecipeSO fryingRecipeSO;
    private BurningRecipeSO burningRecipeSO;

    public event EventHandler <IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;    

    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned,
    }
    private State state;

    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }

    private void Start()
    {
        state = State.Idle;
    }
    private void Update()
    {
        if(HasKitchenObject()) {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Frying:
                    fryingTimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                        progressNormalized = fryingTimer/fryingRecipeSO.fryingTimerMax
                    });
                    if(fryingTimer >= fryingRecipeSO.fryingTimerMax)
                    {
                        //Cook the meat.
                        Debug.Log("Fried");
                        state = State.Fried;
                        burningTimer = 0f;
                        GetKitchenObject().DestrySelf();
                        kitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
                        fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                            state = state
                        });
                    }
                    break;
                case State.Fried:
                    burningTimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                        progressNormalized = burningTimer/fryingRecipeSO.fryingTimerMax
                    });
                    if(burningTimer >= fryingRecipeSO.fryingTimerMax)
                    {
                        //Burn the meat.
                        Debug.Log("Burned");
                        state = State.Burned;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                            state = state
                        });

                        GetKitchenObject().DestrySelf();
                        kitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);

                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                            progressNormalized = 0
                        });
                    }
                    break;
                case State.Burned:
                    break;
            }
        }
    }
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetIKitchenObjectParent(this);
                    state = State.Frying;
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                            state = state
                    });
                    fryingTimer = 0f;
                    fryingRecipeSO = GetFryingRecipeSOWithInput(player.GetKitchenObject().GetKitchenObjectSO());
                    // cuttingProgress = 0;
                    // OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs {
                    //     progressNormalized = (float)cuttingProgress/fryingRecipeSO.cuttingProgressMax
                    // });
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                        progressNormalized = fryingTimer / fryingRecipeSO.fryingTimerMax
                    });
                }
                
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                GetKitchenObject().SetIKitchenObjectParent(player);
                state  = State.Idle;
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                            state = state
                });

                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                    progressNormalized = 0
                });
            }
            else
            {
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestrySelf();

                        state  = State.Idle;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                                    state = state
                        });

                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                            progressNormalized = 0
                        });
                    }
                }
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        fryingRecipeSO = GetFryingRecipeSOWithInput(input);
        return fryingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input)
    {
        fryingRecipeSO = GetFryingRecipeSOWithInput(input);
        if(fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        return null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach(FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if(fryingRecipeSO.input == input)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }

    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach(BurningRecipeSO fryingRecipeSO in burningRecipeSOArray)
        {
            if(fryingRecipeSO.input == input)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }
}
