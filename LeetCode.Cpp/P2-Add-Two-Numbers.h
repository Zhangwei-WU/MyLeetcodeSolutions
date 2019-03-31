#pragma once

#include "ListNode.h"

namespace P2
{
	class Solution 
	{
	public:
		ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) 
		{
			auto head = new ListNode(0);

			auto p1 = l1, p2 = l2, p = head;
			int add = 0;
			while (p1 != NULL || p2 != NULL || add != 0)
			{
				p->next = new ListNode(add);
				if (p1 != NULL) { p->next->val += p1->val; p1 = p1->next; }
				if (p2 != NULL) { p->next->val += p2->val; p2 = p2->next; }

				add = 0;
				if (p->next->val >= 10) 
				{
					add = 1;
					p->next->val -= 10;
				}

				p = p->next;
			}

			return head->next;
		}
	};
}