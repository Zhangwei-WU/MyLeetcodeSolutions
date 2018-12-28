#pragma once

#include<map>

namespace P238
{
    struct RandomListNode {
        int label;
        RandomListNode *next, *random;
        RandomListNode(int x) : label(x), next(nullptr), random(nullptr) {}
    };

    class Solution
    {
    public:

        RandomListNode * copyRandomList(RandomListNode *head)
        {
            std::map<RandomListNode *, RandomListNode *> mapping;

            RandomListNode *p = head;
            RandomListNode *pPrev = NULL;

            while (p != NULL)
            {
                RandomListNode *pCopy = NULL;
                std::map<RandomListNode *, RandomListNode *>::iterator find = mapping.find(p);
                if (find == mapping.end())
                {
                    pCopy = new RandomListNode(p->label);
                    mapping.insert(std::map<RandomListNode *, RandomListNode *>::value_type(p, pCopy));
                }
                else pCopy = find->second;

                p = p->next;

                if (pPrev != NULL) pPrev->next = pCopy;
                pPrev = pCopy;
            }

            p = head;
            while (p != NULL)
            {
                if (p->random != NULL)
                {
                    std::map<RandomListNode *, RandomListNode *>::iterator find = mapping.find(p->random);
                    std::map<RandomListNode *, RandomListNode *>::iterator find2 = mapping.find(p);
                    find2->second->random = find->second;
                }

                p = p->next;
            }

            return head == NULL ? NULL : mapping.find(head)->second;
        }
    };
}